    public class AuthenticationHelper {
        readonly MembershipProvider _provider;
        public AuthenticationHelper(MembershipProvider provider) {
            _provider = provider;
        }
        public string PasswordRecoveryStep2(string userName, string recoveryAnswer) {
            MembershipUser user = _provider.GetUser(userName, false);
            string newPassword = user.ResetPassword(recoveryAnswer);
            return newPassword;
        }
    }
