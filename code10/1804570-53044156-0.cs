        Word.InlineShape ils = doc.InlineShapes[1];
        object oIls = ils;
        object isDec = oIls.GetType().InvokeMember("Decorative", System.Reflection.BindingFlags.GetProperty, null, oIls, null);
        System.Diagnostics.Debug.Print("Is the InlineShape marked as decorative: " + isDec.ToString());
        if ((int)isDec != -1)
        {
            object[] arg = new object[] { -1 };
            oIls.GetType().InvokeMember("Decorative", System.Reflection.BindingFlags.SetProperty, null, oIls, arg);
        }
