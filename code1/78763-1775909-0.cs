    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    public enum DiceExpressionOptions
    {
        None,
        SimplifyStringValue
    }
    public class DiceExpression
    {
        /* <expr> :=   <expr> + <expr>
         *           | <expr> - <expr>
         *           | [<number>]d(<number>|%)
         *           | <number>
         * <number> := positive integer
         * */
        private static readonly Regex numberToken = new Regex("^[0-9]+$");
        private static readonly Regex diceRollToken = new Regex("^([0-9]*)d([0-9]+|%)$");
        public static readonly DiceExpression Zero = new DiceExpression("0");
        private List<KeyValuePair<int, IDiceExpressionNode>> nodes = new List<KeyValuePair<int, IDiceExpressionNode>>();
        public DiceExpression(string expression)
            : this(expression, DiceExpressionOptions.None)
        { }
        public DiceExpression(string expression, DiceExpressionOptions options)
        {
            // A well-formed dice expression's tokens will be either +, -, an integer, or XdY.
            var tokens = expression.Replace("+", " + ").Replace("-", " - ").Split(' ', StringSplitOptions.RemoveEmptyEntries);
            // Blank dice expressions end up being DiceExpression.Zero.
            if (!tokens.Any())
            {
                tokens = new[] { "0" };
            }
            // Since we parse tokens in operator-then-operand pairs, make sure the first token is an operand.
            if (tokens[0] != "+" && tokens[0] != "-")
            {
                tokens = (new[] { "+" }).Concat(tokens).ToArray();
            }
            // This is a precondition for the below parsing loop to make any sense.
            if (tokens.Length % 2 != 0)
            {
                throw new ArgumentException("The given dice expression was not in an expected format: even after normalization, it contained an odd number of tokens.");
            }
            // Parse operator-then-operand pairs into this.nodes.
            for (int tokenIndex = 0; tokenIndex < tokens.Length; tokenIndex += 2)
            {
                var token = tokens[tokenIndex];
                var nextToken = tokens[tokenIndex + 1];
                if (token != "+" && token != "-")
                {
                    throw new ArgumentException("The given dice expression was not in an expected format.");
                }
                int multiplier = token == "+" ? +1 : -1;
                if (DiceExpression.numberToken.IsMatch(nextToken))
                {
                    this.nodes.Add(new KeyValuePair<int, IDiceExpressionNode>(multiplier, new NumberNode(int.Parse(nextToken))));
                }
                else if (DiceExpression.diceRollToken.IsMatch(nextToken))
                {
                    var match = DiceExpression.diceRollToken.Match(nextToken);
                    int numberOfDice = match.Groups[1].Value == string.Empty ? 1 : int.Parse(match.Groups[1].Value);
                    int diceType = match.Groups[2].Value == "%" ? 100 : int.Parse(match.Groups[2].Value);
                    this.nodes.Add(new KeyValuePair<int, IDiceExpressionNode>(multiplier, new DiceRollNode(numberOfDice, diceType)));
                }
                else
                {
                    throw new ArgumentException("The given dice expression was not in an expected format: the non-operand token was neither a number nor a dice-roll expression.");
                }
            }
            // Sort the nodes in an aesthetically-pleasing fashion.
            var diceRollNodes = this.nodes.Where(pair => pair.Value.GetType() == typeof(DiceRollNode))
                                          .OrderByDescending(node => node.Key)
                                          .ThenByDescending(node => ((DiceRollNode)node.Value).DiceType)
                                          .ThenByDescending(node => ((DiceRollNode)node.Value).NumberOfDice);
            var numberNodes = this.nodes.Where(pair => pair.Value.GetType() == typeof(NumberNode))
                                        .OrderByDescending(node => node.Key)
                                        .ThenByDescending(node => node.Value.Evaluate());
            // If desired, merge all number nodes together, and merge dice nodes of the same type together.
            if (options == DiceExpressionOptions.SimplifyStringValue)
            {
                int number = numberNodes.Sum(pair => pair.Key * pair.Value.Evaluate());
                var diceTypes = diceRollNodes.Select(node => ((DiceRollNode)node.Value).DiceType).Distinct();
                var normalizedDiceRollNodes = from type in diceTypes
                                              let numDiceOfThisType = diceRollNodes.Where(node => ((DiceRollNode)node.Value).DiceType == type).Sum(node => node.Key * ((DiceRollNode)node.Value).NumberOfDice)
                                              where numDiceOfThisType != 0
                                              let multiplicand = numDiceOfThisType > 0 ? +1 : -1
                                              let absNumDice = Math.Abs(numDiceOfThisType)
                                              orderby multiplicand descending
                                              orderby type descending
                                              select new KeyValuePair<int, IDiceExpressionNode>(multiplicand, new DiceRollNode(absNumDice, type));
                this.nodes = (number == 0 ? normalizedDiceRollNodes
                                          : normalizedDiceRollNodes.Concat(new[] { new KeyValuePair<int, IDiceExpressionNode>(number > 0 ? +1 : -1, new NumberNode(number)) })).ToList();
            }
            // Otherwise, just put the dice-roll nodes first, then the number nodes.
            else
            {
                this.nodes = diceRollNodes.Concat(numberNodes).ToList();
            }
        }
        public override string ToString()
        {
            string result = (this.nodes[0].Key == -1 ? "-" : string.Empty) + this.nodes[0].Value.ToString();
            foreach (var pair in this.nodes.Skip(1))
            {
                result += pair.Key == +1 ? " + " : " − "; // NOTE: unicode minus sign, not hyphen-minus '-'.
                result += pair.Value.ToString();
            }
            return result;
        }
        public int Evaluate()
        {
            int result = 0;
            foreach (var pair in this.nodes)
            {
                result += pair.Key * pair.Value.Evaluate();
            }
            return result;
        }
        public decimal GetCalculatedAverage()
        {
            decimal result = 0;
            foreach (var pair in this.nodes)
            {
                result += pair.Key * pair.Value.GetCalculatedAverage();
            }
            return result;
        }
        private interface IDiceExpressionNode
        {
            int Evaluate();
            decimal GetCalculatedAverage();
        }
        private class NumberNode : IDiceExpressionNode
        {
            private int theNumber;
            public NumberNode(int theNumber)
            {
                this.theNumber = theNumber;
            }
            public int Evaluate()
            {
                return this.theNumber;
            }
            public decimal GetCalculatedAverage()
            {
                return this.theNumber;
            }
            public override string ToString()
            {
                return this.theNumber.ToString();
            }
        }
        private class DiceRollNode : IDiceExpressionNode
        {
            private static readonly Random roller = new Random();
            private int numberOfDice;
            private int diceType;
            public DiceRollNode(int numberOfDice, int diceType)
            {
                this.numberOfDice = numberOfDice;
                this.diceType = diceType;
            }
            public int Evaluate()
            {
                int total = 0;
                for (int i = 0; i < this.numberOfDice; ++i)
                {
                    total += DiceRollNode.roller.Next(1, this.diceType + 1);
                }
                return total;
            }
            public decimal GetCalculatedAverage()
            {
                return this.numberOfDice * ((this.diceType + 1.0m) / 2.0m);
            }
            public override string ToString()
            {
                return string.Format("{0}d{1}", this.numberOfDice, this.diceType);
            }
            public int NumberOfDice
            {
                get { return this.numberOfDice; }
            }
            public int DiceType
            {
                get { return this.diceType; }
            }
        }
    }
