    public class TheFirst
    {
        [MessageBodyMember]
        public string AOfTheFirst { get; set; }
        [MessageBodyMember]
        public string BOfTheFirst { get; set; }
    }
  
    public class TheSecond
    {
        [MessageBodyMember]
        public string AOfTheFirst { get; set; }
        [MessageBodyMember]
        public string BOfTheFirst { get; set; }
    }
    [MessageContract(IsWrapped = false)]  //IsWrapped= "false" removes the OuterClasselement in the request element
    public class OuterClass{
        [MessageBodyMember(Namespace ="www.thefirst.com",Name ="aliasForFirst")]
        public TheFirst TheFirst { get; set; }
        [MessageBodyMember(Namespace ="www.thesecond.com",Name ="aliasForSecond")]
        public TheSecond TheSecond { get; set; }
        
    }
