    class ParameterVisitor : SqlCodeObjectRecursiveVisitor {
        HashSet<string> referencedVariables = new HashSet<string>();
        public override void Visit(SqlScalarVariableRefExpression codeObject) {
            referencedVariables.Add(codeObject.VariableName);
        }
        HashSet<string> declaredVariables = new HashSet<string>();
        public override void Visit(SqlVariableDeclaration codeObject) {
            declaredVariables.Add(codeObject.Name);
        }
        public override void Visit(SqlBatch codeObject) {
            base.Visit(codeObject);
            parameters = referencedVariables.Except(declaredVariables).ToList();
        }
        List<string> parameters;
        public IEnumerable<string> Parameters => parameters;
    }
