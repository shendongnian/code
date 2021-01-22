    using System;
    using System.Collections.Generic;
    using System.Text.RegularExpressions;
    
    namespace StackOverflow
    {
        class Start
        {
            public static void Main(string[] args)
            {
                Evaluator ev;
                string variableValue, eq;
            Console.Write("Enter equation:  ");
            eq = Console.ReadLine();
            while (eq != "quit")
            {
                ev = new Evaluator(eq);
                foreach (Variable v in ev.Variables)
                {
                    Console.Write(v.Name + " = ");
                    variableValue = Console.ReadLine();
                    ev.SetVariable(v.Name, Convert.ToDecimal(variableValue));
                }
                Console.WriteLine(ev.Evaluate());
                Console.Write("Enter equation:  ");
                eq = Console.ReadLine();
            }
        }
    }
    class EvalNode
    {
        public virtual decimal Evaluate()
        {
            return decimal.Zero;
        }
    }
    class ValueNode : EvalNode
    {
        decimal value;
        public ValueNode(decimal v)
        {
            value = v;
        }
        public override decimal Evaluate()
        {
            return value;
        }
        public override string ToString()
        {
            return value.ToString();
        }
    }
    class FunctionNode : EvalNode
    {
        EvalNode lhs = new ValueNode(decimal.Zero);
        EvalNode rhs = new ValueNode(decimal.Zero);
        string op = "+";
        public string Op
        {
            get { return op; }
            set
            {
                op = value;
            }
        }
        internal EvalNode Rhs
        {
            get { return rhs; }
            set
            {
                rhs = value;
            }
        }
        internal EvalNode Lhs
        {
            get { return lhs; }
            set
            {
                lhs = value;
            }
        }
        public override decimal Evaluate()
        {
            decimal result = decimal.Zero;
            switch (op)
            {
                case "+":
                    result = lhs.Evaluate() + rhs.Evaluate();
                    break;
                case "-":
                    result = lhs.Evaluate() - rhs.Evaluate();
                    break;
                case "*":
                    result = lhs.Evaluate() * rhs.Evaluate();
                    break;
                case "/":
                    result = lhs.Evaluate() / rhs.Evaluate();
                    break;
                case "%":
                    result = lhs.Evaluate() % rhs.Evaluate();
                    break;
                case "^":
                    double x = Convert.ToDouble(lhs.Evaluate());
                    double y = Convert.ToDouble(rhs.Evaluate());
                    result = Convert.ToDecimal(Math.Pow(x, y));
                    break;
                case "!":
                    result = Factorial(lhs.Evaluate());
                    break;
            }
            return result;
        }
        private decimal Factorial(decimal factor)
        {
            if (factor < 1)
                return 1;
            return factor * Factorial(factor - 1);
        }
        public override string ToString()
        {
            return "(" + lhs.ToString() + " " + op + " " + rhs.ToString() + ")";
        }
    }
    public class Evaluator
    {
        string equation = "";
        Dictionary<string, Variable> variables = new Dictionary<string, Variable>();
        public string Equation
        {
            get { return equation; }
            set { equation = value; }
        }
        public Variable[] Variables
        {
            get { return new List<Variable>(variables.Values).ToArray(); }
        }
        public void SetVariable(string name, decimal value)
        {
            if (variables.ContainsKey(name))
            {
                Variable x = variables[name];
                x.Value = value;
                variables[name] = x;
            }
        }
        public Evaluator(string equation)
        {
            this.equation = equation;
            SetVariables();
        }
        public decimal Evaluate()
        {
            return Evaluate(equation, new List<Variable>(variables.Values));
        }
        public decimal Evaluate(string text)
        {
            decimal result = decimal.Zero;
            equation = text;
            EvalNode parsed;
            equation = equation.Replace(" ", "");
            parsed = Parse(equation, "qx");
            if (parsed != null)
                result = parsed.Evaluate();
            return result;
        }
        public decimal Evaluate(string text, List<Variable> variables)
        {
            foreach (Variable v in variables)
            {
                text = text.Replace(v.Name, v.Value.ToString());
            }
            return Evaluate(text);
        }
        private static bool EquationHasVariables(string equation)
        {
            Regex letters = new Regex(@"[A-Za-z]");
            return letters.IsMatch(equation);
        }
        private void SetVariables()
        {
            Regex letters = new Regex(@"([A-Za-z]+)");
            Variable v;
            foreach (Match m in letters.Matches(equation, 0))
            {
                v = new Variable(m.Groups[1].Value, decimal.Zero);
                if (!variables.ContainsKey(v.Name))
                {
                    variables.Add(v.Name, v);
                }
            }
        }
        #region Parse V2
        private Dictionary<string, string> parenthesesText = new Dictionary<string, string>();
        /*
         * 1.  All the text in first-level parentheses is replaced with replaceText plus an index value.
         *      (All nested parentheses are parsed in recursive calls)
         * 2.  The simple function is parsed given the order of operations (reverse priority to 
         *      keep the order of operations correct when evaluating).
         *      a.  Addition (+), subtraction (-)                   -> left to right
         *      b.  Multiplication (*), division (/), modulo (%)    -> left to right
         *      c.  Exponents (^)                                   -> right to left
         *      d.  Factorials (!)                                  -> left to right
         *      e.  No op (number, replaced parentheses) 
         * 3.  When an op is found, a two recursive calls are generated -- parsing the LHS and 
         *      parsing the RHS.
         * 4.  An EvalNode representing the root node of the evaluations tree is returned.
         * 
         * Ex.  3 + 5                   (3 + 5) * 8
         *           +                          *
         *          / \                        / \
         *         3   5                      +   8
         *                                   / \ 
         *      3 + 5 * 8                   3   5
         *            +
         *           / \
         *          3   *
         *             / \
         *            5   8
         */
        /// <summary>
        /// Parses the expression and returns the root node of a tree.
        /// </summary>
        /// <param name="eq">Equation to be parsed</param>
        /// <param name="replaceText">Text base that replaces text in parentheses</param>
        /// <returns></returns>
        private EvalNode Parse(string eq, string replaceText)
        {
            int randomKeyIndex = 0;
            eq = eq.Replace(" ", "");
            if (eq.Length == 0)
            {
                return new ValueNode(decimal.Zero);
            }
            int leftParentIndex = -1;
            int rightParentIndex = -1;
            SetIndexes(eq, ref leftParentIndex, ref rightParentIndex);
            //remove extraneous outer parentheses
            while (leftParentIndex == 0 && rightParentIndex == eq.Length - 1)
            {
                eq = eq.Substring(1, eq.Length - 2);
                SetIndexes(eq, ref leftParentIndex, ref rightParentIndex);
            }
            //Pull out all expressions in parentheses
            replaceText = GetNextReplaceText(replaceText, randomKeyIndex);
            while (leftParentIndex != -1 && rightParentIndex != -1)
            {
                //replace the string with a random set of characters, stored extracted text in dictionary keyed on the random set of chars
                string p = eq.Substring(leftParentIndex, rightParentIndex - leftParentIndex + 1);
                eq = eq.Replace(p, replaceText);
                parenthesesText.Add(replaceText, p);
                leftParentIndex = 0;
                rightParentIndex = 0;
                replaceText = replaceText.Remove(replaceText.LastIndexOf(randomKeyIndex.ToString()));
                randomKeyIndex++;
                replaceText = GetNextReplaceText(replaceText, randomKeyIndex);
                SetIndexes(eq, ref leftParentIndex, ref rightParentIndex);
            }
            /*
             * Be sure to implement these operators in the function node class
             */
            char[] ops_order0 = new char[2] { '+', '-' };
            char[] ops_order1 = new char[3] { '*', '/', '%' };
            char[] ops_order2 = new char[1] { '^' };
            char[] ops_order3 = new char[1] { '!' };
            /*
             * In order to evaluate nodes LTR, the right-most node must be the root node
             * of the tree, which is why we find the last index of LTR ops.  The reverse 
             * is the case for RTL ops.
             */
            int order0Index = eq.LastIndexOfAny(ops_order0);
            if (order0Index > -1)
            {
                return CreateFunctionNode(eq, order0Index, replaceText + "0");
            }
            int order1Index = eq.LastIndexOfAny(ops_order1);
            if (order1Index > -1)
            {
                return CreateFunctionNode(eq, order1Index, replaceText + "0");
            }
            int order2Index = eq.IndexOfAny(ops_order2);
            if (order2Index > -1)
            {
                return CreateFunctionNode(eq, order2Index, replaceText + "0");
            }
            int order3Index = eq.LastIndexOfAny(ops_order3);
            if (order3Index > -1)
            {
                return CreateFunctionNode(eq, order3Index, replaceText + "0");
            }
            //no operators...
            eq = eq.Replace("(", "");
            eq = eq.Replace(")", "");
            if (char.IsLetter(eq[0]))
            {
                return Parse(parenthesesText[eq], replaceText + "0");
            }
            return new ValueNode(decimal.Parse(eq));
        }
        private string GetNextReplaceText(string replaceText, int randomKeyIndex)
        {
            while (parenthesesText.ContainsKey(replaceText))
            {
                replaceText = replaceText + randomKeyIndex.ToString();
            }
            return replaceText;
        }
        private EvalNode CreateFunctionNode(string eq, int index, string randomKey)
        {
            FunctionNode func = new FunctionNode();
            func.Op = eq[index].ToString();
            func.Lhs = Parse(eq.Substring(0, index), randomKey);
            func.Rhs = Parse(eq.Substring(index + 1), randomKey);
            return func;
        }
        #endregion
        /// <summary>
        /// Find the first set of parentheses
        /// </summary>
        /// <param name="eq"></param>
        /// <param name="leftParentIndex"></param>
        /// <param name="rightParentIndex"></param>
        private static void SetIndexes(string eq, ref int leftParentIndex, ref int rightParentIndex)
        {
            leftParentIndex = eq.IndexOf('(');
            rightParentIndex = eq.IndexOf(')');
            int tempIndex = eq.IndexOf('(', leftParentIndex + 1);
            while (tempIndex != -1 && tempIndex < rightParentIndex)
            {
                rightParentIndex = eq.IndexOf(')', rightParentIndex + 1);
                tempIndex = eq.IndexOf('(', tempIndex + 1);
            }
        }
    }
    public struct Variable
    {
        public string Name;
        public decimal Value;
        public Variable(string n, decimal v)
        {
            Name = n;
            Value = v;
            }
        }
    }
