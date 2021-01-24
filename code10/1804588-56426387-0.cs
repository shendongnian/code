    public abstract class BaseSetting {}
    public abstract class AccountSetting : BaseSetting {}
    public abstract class UserSetting : BaseSetting {}
    public class AccountSettingA : AccountSetting {}
    public class AccountSettingB : AccountSetting {}
    public class UserSettingA : UserSetting {}
    public class UserSettingB : UserSetting {}
