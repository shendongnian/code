            private QueryNode ParseRealLiteral()
            {
                this.ValidateToken(QueryTokenKind.RealLiteral, () => "Expected real literal.");
                string text = this.lexer.Token.Text;
                char last = Char.ToUpper(text[text.Length - 1]);
                if (last == 'F' || last == 'M' || last == 'D')
                {
                    // so terminating F/f, M/m, D/d have no effect.
                    text = text.Substring(0, text.Length - 1);
                }
                object value = null;
                switch (last)
                {
                    case 'M':
                        decimal mVal;
                        if (Decimal.TryParse(text, out mVal))
                        {
                            value = mVal;
                        }
                        break;
                    case 'F':
                        float fVal;
                        if (Single.TryParse(text, out fVal))
                        {
                            value = fVal;
                        }
                        break;
                    case 'D':
                    default:
                        double dVal;
                        if (Double.TryParse(text, out dVal))
                        {
                            value = dVal;
                        }
                        break;
                }
                if (value == null)
                {
                    this.ParseError("The specified odata query has invalid real literal '{0}'.".FormatInvariant(text), this.lexer.Token.Position);
                }
                this.lexer.NextToken();
                return new ConstantNode(value);
            }
