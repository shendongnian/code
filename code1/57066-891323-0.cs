        container.Configure<InjectedMembers>().ConfigureInjectionFor<IAuthenticationForm>();
        containers.Configure(container);
        IAuthenticationForm f = container.Resolve<IAuthenticationForm>();
        f.ShowDialog();
    public interface IAuthenticationForm
    {
        Optimal4.Services.Authentication.IAuthorization Authorizor { get; set; }
        void checkAuthentication();
        System.Windows.Forms.DialogResult ShowDialog();
    }
