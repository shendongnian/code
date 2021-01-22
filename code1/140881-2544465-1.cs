     private static void ApplyChannelProtectionRequirements(BindingContext context)
        {
            var cpr = context.BindingParameters.Find<ChannelProtectionRequirements>();
            if (cpr != null)
            {
                XmlQualifiedName qName = new XmlQualifiedName("customHeader", "namespace");
                MessagePartSpecification part = new MessagePartSpecification(qName);
                cpr.IncomingEncryptionParts.AddParts(part, "incomingAction");
                cpr.IncomingSignatureParts.AddParts(part, "incomingAction");
                cpr.OutgoingEncryptionParts.AddParts(part, "outgoingAction");
                cpr.OutgoingSignatureParts.AddParts(part, "outgoingAction");
            }
        }
