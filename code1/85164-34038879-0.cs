    internal class SpellChecker
    {
        public SpellChecker()
        {
        }
        public static string Check(string text)
        {
            bool flag;
            string str = text;
            flag = (text == null ? true : !(text != ""));
            bool flag1 = flag;
            if (!flag1)
            {
                Type typeFromProgID = Type.GetTypeFromProgID("Word.Application");
                object obj = Activator.CreateInstance(typeFromProgID);
                object[] objArray = new object[1];
                object obj1 = typeFromProgID.InvokeMember("Documents", BindingFlags.GetProperty, null, obj, null);
                object obj2 = obj1.GetType().InvokeMember("Add", BindingFlags.InvokeMethod, null, obj1, null);
                object obj3 = obj2.GetType().InvokeMember("ActiveWindow", BindingFlags.GetProperty, null, obj2, null);
                objArray[0] = 0;
                obj3.GetType().InvokeMember("WindowState", BindingFlags.SetProperty, null, obj3, objArray);
                object[] objArray1 = new object[] { -2000, -2000 };
                obj.GetType().InvokeMember("Move", BindingFlags.InvokeMethod, null, obj, objArray1);
                objArray[0] = "Spell Check";
                obj3.GetType().InvokeMember("Caption", BindingFlags.SetProperty, null, obj3, objArray);
                object obj4 = typeFromProgID.InvokeMember("Selection", BindingFlags.GetProperty, null, obj, null);
                objArray[0] = text;
                obj4.GetType().InvokeMember("TypeText", BindingFlags.InvokeMethod, null, obj4, objArray);
                objArray[0] = 6;
                obj4.GetType().InvokeMember("HomeKey", BindingFlags.InvokeMethod, null, obj4, objArray);
                object obj5 = obj2.GetType().InvokeMember("SpellingErrors", BindingFlags.GetProperty, null, obj2, null);
                int num = (int)obj5.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, obj5, null);
                flag1 = num <= 0;
                if (flag1)
                {
                    System.Windows.Forms.MessageBox.Show("Spellcheck is correct");
                }
                else
                {
                    obj3.GetType().InvokeMember("Activate", BindingFlags.InvokeMethod, null, obj3, null);
                    objArray1 = new object[] { -5000, -5000 };
                    obj.GetType().InvokeMember("Move", BindingFlags.InvokeMethod, null, obj, objArray1);
                    objArray[0] = true;
                    obj.GetType().InvokeMember("Visible", BindingFlags.SetProperty, null, obj, objArray);
                    obj2.GetType().InvokeMember("CheckSpelling", BindingFlags.InvokeMethod, null, obj2, null);
                    objArray[0] = true;
                    obj2.GetType().InvokeMember("Saved", BindingFlags.SetProperty, null, obj2, objArray);
                    object obj6 = obj2.GetType().InvokeMember("Content", BindingFlags.GetProperty, null, obj2, null);
                    str = obj6.GetType().InvokeMember("Text", BindingFlags.GetProperty, null, obj6, null).ToString();
                    str = str.Trim();
                }
                flag1 = obj == null;
                if (!flag1)
                {
                    objArray[0] = true;
                    obj2.GetType().InvokeMember("Saved", BindingFlags.SetProperty, null, obj2, objArray);
                    obj.GetType().InvokeMember("Quit", BindingFlags.InvokeMethod, null, obj, null);
                }
            }
            string str1 = str;
            return str1;
        }
    }
