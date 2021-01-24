    public class DataClass
    {
        private readonly IClass1 _class1;
        public DataClass(IClass1 class1)
        {
            _class1 = class1;   
        }
        public DataSet ExecuteCondition()
        {
                //....
            var result = _class1.VerifyPrecondition(query);
                //....
        }
    }
