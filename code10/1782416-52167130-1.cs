    public interface IEmail {
        Task SendAsync(Contato contato);
    }
    public class Email: IEmail {
        //...omitted for brevity
    }
