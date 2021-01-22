        MemoryStream ms = new MemoryStream();
        EventRaisingStreamWriter outputWr = new EventRaisingStreamWriter(ms);
        outputWr.StringWritten += new EventHandler<MyEvtArgs<string>>(sWr_StringWritten);
        var engine = Python.CreateEngine();
        engine.Runtime.IO.SetOutput(ms, outputWr);
        engine.CreateScriptSourceFromString("print 'hello world!'").Execute();
        void sWr_StringWritten(object sender, MyEvtArgs<string> e)
        {
            textBox1.Text += e.Value;
        }
