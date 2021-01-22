            Assembly currentAssembly = Assembly.GetExecutingAssembly();
            List<Form> formsFromOtherAssemblies = new List<Form>();
            foreach (Form form in Application.OpenForms) {
                if (form.GetType().Assembly != currentAssembly) {
                    formsFromOtherAssemblies.Add(form);
                }
            }
