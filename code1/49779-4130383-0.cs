    public enum ControlSelectionType    
    {   
        NotApplicable = 1,   
        SingleSelectRadioButtons = 2,   
        SingleSelectDropDownList = 3,   
        MultiSelectCheckBox = 4,   
        MultiSelectListBox = 5   
    } 
    public class NameValue
    {
        public string Name { get; set; }
        public object Value { get; set; }
    }    
    public static List<NameValue> EnumToList<T>(bool camelcase)
            {
                var array = (T[])(Enum.GetValues(typeof(T)).Cast<T>()); 
                var array2 = Enum.GetNames(typeof(T)).ToArray<string>(); 
                List<NameValue> lst = null;
                for (int i = 0; i < array.Length; i++)
                {
                    if (lst == null)
                        lst = new List<NameValue>();
                    string name = "";
                    if (camelcase)
                    {
                        name = array2[i].CamelCaseFriendly();
                    }
                    else
                        name = array2[i];
                    T value = array[i];
                    lst.Add(new NameValue { Name = name, Value = value });
                }
                return lst;
            }
            public static string CamelCaseFriendly(this string pascalCaseString)
            {
                Regex r = new Regex("(?<=[a-z])(?<x>[A-Z])|(?<=.)(?<x>[A-Z])(?=[a-z])");
                return r.Replace(pascalCaseString, " ${x}");
            }
    
    //In  your form 
    protected void Button1_Click1(object sender, EventArgs e)
            {
                DropDownList1.DataSource = GeneralClass.EnumToList<ControlSelectionType  >(true); ;
                DropDownList1.DataTextField = "Name";
                DropDownList1.DataValueField = "Value";
    
                DropDownList1.DataBind();
            }
