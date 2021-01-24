    public sealed class TreeEvaluationVisitor : TestBaseVisitor<Object> {
       public override object VisitText([NotNull] TestParser.TextContext context) {
            int string_length = context.TEXT().ToString().Length;
            return context.TEXT().ToString().Substring(1, string_length - 2);     
            //Substring() up here is for omitting the quote marks in the final output
        }
        public override object VisitUpperCase([NotNull] TestParser.UpperCaseContext context) {
            int string_length = Visit(context.expression()).ToString().Length;
            return Visit(context.expression()).ToString().ToUpper();
        }
        public override object VisitLowerCase([NotNull] TestParser.LowerCaseContext context) {
            int string_length = Visit(context.expression()).ToString().Length;
            return Visit(context.expression()).ToString().ToLower();
        }
        public override object VisitShiftLeft([NotNull] TestParser.ShiftLeftContext context) {
            int n = int.Parse(context.NUMBER().ToString());
            return sh_left(Visit(context.expression()).ToString(), n);
        }
        public override object VisitShiftRight([NotNull] TestParser.ShiftRightContext context) {
            int n = int.Parse(context.NUMBER().ToString());
            return sh_right(Visit(context.expression()).ToString(), n);
        }
        public override object VisitConcatenate([NotNull] TestParser.ConcatenateContext context) {
            string left = Visit(context.expression(0)).ToString();
            string right = Visit(context.expression(1)).ToString();
            return left + right;
        }
        public override object VisitSubstring([NotNull] TestParser.SubstringContext context) {
            
            int n1 = int.Parse(context.NUMBER(0).ToString());
            int n2 = int.Parse(context.NUMBER(1).ToString());
            return Visit(context.expression()).ToString().Substring(n1, n2);
        }
        //shift methods for shifting strings, i. e. left("abc",2) -> result = cab
        private static string sh_left(string chain, int amount) {  
            return (chain.Substring(amount) + chain.Substring(0, amount));
        }
        private static string sh_right(string chain, int amount) {
            return chain.Substring(chain.Length - amount) 
                   + chain.Substring(0, chain.Length - amount);
        }
