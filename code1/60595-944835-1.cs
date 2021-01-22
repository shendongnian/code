    public class CurrentUse
    {
        public static SpecialList<DataType1> Data1
        {
            get
            {
                SpecialList<DataType1> list = new SpecialList<DataType1>();
                list.Add("someStuff", data => data.fieldA);
                list.Add("someOtherStuff", data => data.fieldB);
                return list;
            }
        }
