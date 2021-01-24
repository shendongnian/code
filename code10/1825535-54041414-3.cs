    public class EmptyCommand : IRequest{...}
    
    public class EmptyCommandHandler : RequestHandler<EmptyCommand>
    {
        protected override void Handle(EmptyCommand request){...}
    }
