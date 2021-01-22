     private static void ApplyChannelProtectionRequirements(BindingContext context)
        {
            var cpr = context.BindingParameters.Find<ChannelProtectionRequirements>();
            if (cpr != null)
            {
                XmlQualifiedName qName = new XmlQualifiedName("customHeader", "namespace");
                MessagePartSpecification part = new MessagePartSpecification(qName);
                cpr.IncomingEncryptionParts.AddParts(part, "inctomingAction");
                cpr.IncomingSignatureParts.AddParts(part, "inctomingAction");
                cpr.OutgoingEncryptionParts.AddParts(part, "outgoingAction");
                cpr.OutgoingSignatureParts.AddParts(part, "outgoingAction");
            }
        }
