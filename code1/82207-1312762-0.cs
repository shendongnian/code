    public class MyClass
    {
        int value;
        public void Test(int value)
        {
            MessageBox.Show(value); // Will show the parameter to the function
            MessageBox.Show(this.value); // Will show the field in the object
        }
    }
