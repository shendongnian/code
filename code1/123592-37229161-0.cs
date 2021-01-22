            Type type = Type.GetTypeFromProgID("InDesign.Application");
            Application app = (Application)Activator.CreateInstance(type);
            var doc = app.Documents.Add();
            for (var i = 0; i < 5; i++)
                doc.Pages.Add(idLocationOptions.idAtBeginning);
