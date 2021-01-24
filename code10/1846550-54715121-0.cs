    public class InformationController : ApiController
    {
        private Classes main = new Classes();
        private Information[] Information;
        public InformationController()
        {
            Information = new Information[]
            {
                new Information { Info_ID = 2, fullName = main.getFullname("2"), },
            };
        }
      /// the rest of your code...
