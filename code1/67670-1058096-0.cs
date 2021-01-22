    public interface IMailMessageWrapper
    {
        MailAddressCollection To { get; }
    }
    public class MailMessageWrapper
    {
        private MailMessage Message { get; set; }
        public MailMessageWrapper( MailMessage message )
        {
            this.Message = message;
        }
        public MailAddressCollection To
        {
            get { return this.Message.To; }
        }
    }
    // RhinoMock syntax, sorry -- but I don't use Moq
    public void MessageToTest()
    {
         var message = MockRepository.GenerateMock<IMailMessageWrapper>()
         var to = MockRepository.GenerateMock<MailAddressCollection>();
         var expectedAddress = "test@example.com";
         message.Expect( m => m.To ).Return( to ).Repeat.Any();
         to.Expect( t => t.Add( expectedAddress ) );
         ...
    }
