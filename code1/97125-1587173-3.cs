    StringWriter writer = new StringWriter();
    NVelocity.App.VelocityEngine eng = new NVelocity.App.VelocityEngine();
    try
    {
    	NVelocityEventHandler te = new NVelocityEventHandler();
    	EventCartridge ec = new EventCartridge();
    	ec.AddEventHandler(te);
    	VelocityContext vc = new VelocityContext((IDictionary)parameters);
    	ec.AttachToContext(vc);
    	eng.Evaluate(vc, writer, "templatestring", template);
    }
    catch (ParseErrorException pe)
    {
    	return pe.Message;
    }
    catch (MethodInvocationException mi)
    {
    	return mi.Message;
    }
