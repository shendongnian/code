    void Mymethod(){
    Class1 class1 = new Class1();
    //define properties for class1
    Class1 class2 = new Class1();
    //define properties for class2
    PropertyInfo[] properties = class1.GetType().GetProperties();
    bool bClassesEqual = true;
    foreach (PropertyInfo property in properties)
    {
        Console.WriteLine(property.Name.ToString());
        if (property.GetValue(class1, null) != property.GetValue(class2, null))
        {
            bClassesEqual = false;
            break;
        }
    }
}
