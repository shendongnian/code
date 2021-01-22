        public static bool IsFormVisible(string formName)
        {
            var tester = new FormTester(formName);
            var form = (Form) tester.TheObject;
            return form.Visible;
        }
