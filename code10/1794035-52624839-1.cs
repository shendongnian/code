    public static class Settings //Class is also static
    {
        public static List<Form> OpenedForms = new List<Form>();
        public static int MaxIdOfOpenedForm() //With this method we check max ID of opened form. We will use it later
        {
            int max = -1;
            foreach(Form f in OpenedForms)
            {
                if(Convert.ToInt32(f.Tag) > max)
                    max = Convert.ToInt32(f.Tag);
            }
            return max;
        }
        public static void RemoveSpecificForm(Form form) //Remove specific form from list
        {
            for(int i = 0; i < OpenedForms.Count; i++)
            {
                if((OpenedForms[i] as Form).Tag == form.Tag)
                {
                    OpenedForms.Remove(form);
                    return;
                }
            }
        }
        public static void CloseAllOpenedForms()
        {
            for(int i = 0; i < OpenedForms.Count; i++)
            {
                OpenedForms.Remove(OpenedForms[i]);
            }
        }
    }
