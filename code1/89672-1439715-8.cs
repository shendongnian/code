    namespace MyClientProject
    {
        public class MyClientClass
        {
            public void AskWebServiceForContactInfo()
            {
                using (var service = new DoSomethingService())
                {
                    MyClientProject.DoSomethingService.ContactInfo contactInfo = service.GetContactInfo(1);
                    // We actually get a new object here, of the correct namespace
                    MyProject.ContactInfo localContactInfo = ShallowCopy.Copy<MyClientProject.DoSomethingService.ContactInfo, MyProject.ContactInfo>(contactInfo);
                }
            }
        }
    }
