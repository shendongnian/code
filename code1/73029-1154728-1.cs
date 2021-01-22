    Type tipo = engine.GetType("FullClassName");
    BaseProcesso baseProcesso = (BaseProcesso)Activaor.CreateInstance(tipo, new object[] { "ConstructorParameter1", "ConstructorParameter1") });
    // Event
    baseProcesso.IndicarProgresso += new  BaseProcesso.IndicarProgressoHandler(baseProcesso_IndicarProgresso);
    new Thread(new ThreadStart(baseProcesso.Executar)).Start();
