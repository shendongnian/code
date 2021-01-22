    Message recoverableMessage = new Message();
    recoverableMessage.Recoverable = true;
    recoverableMessage.Body = "Sample Recoverable Message";
    recoverableMessage.Formatter = new XmlMessageFormatter(new String[] {"System.String,mscorlib" });
    MessageQueue myQueue = new MessageQueue(@".\private$\teste");
