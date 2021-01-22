    public class PortChangeReflector : SoapExtensionReflector
    {     
        public override void ReflectDescription()
        {
            ServiceDescription description = ReflectionContext.ServiceDescription;
            foreach (Service service in description.Services)
            {
                foreach (Port port in service.Ports)
                {
                    foreach (ServiceDescriptionFormatExtension extension in port.Extensions)
                    {
                        SoapAddressBinding binding = extension as SoapAddressBinding;
                        if (binding != null && !binding.Location.Contains("8092"))
                        {
                            binding.Location = binding.Location.Replace("92", "8092");
                        }
                    }
                }
            }
        }
    }
