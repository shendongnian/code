    class FormFactory
    {
        public Form1 GetForm1()
        {
            return Application.OpenForms.OfType<Form1>().FirstOrDefault ?? new Form1();
        }
    }
So your FormFactory controls the lifetime of your form, now you can get an existing or new instance of Form1 using new FormFactory.GetForm1().
