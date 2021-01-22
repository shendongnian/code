    namespace MyClientProject
    {
        public class MyClientClass
        {
            public void AskWebServiceForContactInfo()
            {
                using (var service = new DoSomethingService())
                {
                    MyClientProject.DoSomethingService.ContactInfo contactInfo = service.GetContactInfo(1);
    
                    // ERROR: You can't cast this:
                    MyProject.ContactInfo localContactInfo = contactInfo;
                }
            }
        }
    }
