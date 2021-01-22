        /*ToDo : Test Result*/
        static void Main(string[] args)
        {
            /*Test : primivit types*/
            long maxNumber = 123123;
            Tuple<string, long> longVariable = Utility.GetNameAndValue(() => maxNumber);
            string longVariableName = longVariable.Item1;
            long longVariableValue = longVariable.Item2;
            /*Test : user define types*/
            Person aPerson = new Person() { Id = "123", Name = "Roy" };
            Tuple<string, Person> personVariable = Utility.GetNameAndValue(() => aPerson);
            string personVariableName = personVariable.Item1;
            Person personVariableValue = personVariable.Item2;
            /*Test : anonymous types*/
            var ann = new { Id = "123", Name = "Roy" };
            var annVariable = Utility.GetNameAndValue(() => ann);
            string annVariableName = annVariable.Item1;
            var annVariableValue = annVariable.Item2;
            /*Test : Enum tyoes*/
            Active isActive = Active.Yes;
            Tuple<string, Active> isActiveVariable = Utility.GetNameAndValue(() => isActive);
            string isActiveVariableName = isActiveVariable.Item1;
            Active isActiveVariableValue = isActiveVariable.Item2;
        }
