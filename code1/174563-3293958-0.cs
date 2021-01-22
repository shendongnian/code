    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SKYPE4COMLib;
    
    namespace SkypeR
    {
        public class SkypeApplication
        {
            private static readonly SkypeApplication TheInstance = new SkypeApplication();
            private readonly Skype _skype = new Skype();
    
            private SkypeApplication()
            {
                _skype.OnlineStatus += SkypeOnlineStatus;
                _skype.UserStatus += SkypeUserStatus;
                _skype.UserMood += SkypeUserMood;
            }
    
            private void SkypeUserMood(User puser, string moodtext)
            {
                FireUserMood(puser.GetUserInfo(), puser.OnlineStatus.GetStatusValue(), moodtext);
            }
    
            public string MyMood
            {
                get { return _skype.CurrentUserProfile.MoodText; }
                set { _skype.CurrentUserProfile.MoodText = value; }
            }
    
            public static SkypeApplication Instance
            {
                get { return TheInstance; }
            }
    
            public bool Running
            {
                get { return _skype.Client.IsRunning; }
            }
    
            public string Information
            {
                get { return String.Format("v{0}", _skype.Version); }
            }
    
            public Status MyStatus
            {
                get { return _skype.CurrentUserStatus.GetStatusValue(); }
                set { _skype.CurrentUserStatus = value.GetTUserStatusValue(); }
            }
    
            public IEnumerable<Contact> ContactList
            {
                get
                {
                    UserCollection friends = _skype.Friends;
                    return from User user in friends select new Contact
                                                                {
                                                                    UserInfo = user.GetUserInfo(),
                                                                    Status = user.OnlineStatus.GetStatusValue()
                                                                };
                }
            }
    
            private void SkypeUserStatus(TUserStatus status)
            {
                FireUserStatus(status.GetStatusValue());
            }
    
            private void FireUserStatus(Status status)
            {
                if (OnStatusChange != null)
                {
                    OnStatusChange(this, new StatusChangedArgs {Status = status, Time = DateTime.Now});
                }
            }
    
            private void SkypeOnlineStatus(User puser, TOnlineStatus status)
            {
                FireUserStatus(puser.GetUserInfo(), status.GetStatusValue(), puser.MoodText);
            }
    
            public void Start()
            {
                if (!_skype.Client.IsRunning)
                {
                    _skype.Client.Start(true, true);
                }
            }
    
            public void Shutdown()
            {
                if (_skype.Client.IsRunning)
                {
                    _skype.Client.Shutdown();
                }
            }
    
            public event EventHandler<UserSomethingChangedArgs> OnUserStatusChange;
            public event EventHandler<StatusChangedArgs> OnStatusChange;
            public event EventHandler<UserSomethingChangedArgs> OnUserMoodChange;
    
            private void FireUserStatus(UserInfo user, Status newStatus, string userMood)
            {
                if (OnUserStatusChange != null)
                {
                    OnUserStatusChange(this,
                                       new UserSomethingChangedArgs
                                           {
                                               Contact = new Contact {UserInfo = user, Status = newStatus, Mood = userMood},
                                               Time = DateTime.Now
                                           });
                }
            }
    
            public void FireUserMood(UserInfo user, Status userStatus, string newMood)
            {
                if (OnUserMoodChange != null)
                {
                    OnUserMoodChange(this,
                        new UserSomethingChangedArgs
                            {
                                Contact = new Contact { UserInfo = user, Status= userStatus, Mood = newMood },
                                Time = DateTime.Now
                            });
                }
            }
        }
    
        public class StatusChangedArgs : EventArgs
        {
            public Status Status { get; set; }
            public DateTime Time { get; set; }
        }
    
        public class UserSomethingChangedArgs : EventArgs
        {
            public Contact Contact { get; set; }
            public DateTime Time { get; set; }
        }
    
        public enum Sex
        {
            Female,
            Male
        }
    
        public enum Status
        {
            Online,
            Away,
            Offline,
            Unknown,
            DoNotDisturb,
            NotAvailable,
            SkypeMe,
            SkypeOut
        }
    
        public struct UserInfo
        {
            public string Name { get; set; }
            public Sex Sex { get; set; }
    
            public static bool operator ==(UserInfo i1, UserInfo i2)
            {
                return (i1.Name.Equals(i2.Name) && i1.Sex.Equals(i2.Sex));
            }
    
            public static bool operator !=(UserInfo i1, UserInfo i2)
            {
                return (!i1.Sex.Equals(i2.Sex) || !i1.Name.Equals(i2.Name));
            }
    
            public bool Equals(UserInfo other)
            {
                return Equals(other.Name, Name) && Equals(other.Sex, Sex);
            }
    
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                return obj.GetType() == typeof (UserInfo) && Equals((UserInfo) obj);
            }
    
            public override int GetHashCode()
            {
                unchecked
                {
                    return ((Name != null ? Name.GetHashCode() : 0)*397) ^ Sex.GetHashCode();
                }
            }
        }
    
        public class Contact
        {
            public UserInfo UserInfo { get; set; }
            public Status Status { get; set; }
            public string Mood { get; set; }
        }
    
        public static class Extensions
        {
            public static string GetSomeName(this User user)
            {
                if (!string.IsNullOrEmpty(user.FullName))
                    return user.FullName;
                if (!string.IsNullOrEmpty(user.DisplayName))
                    return user.DisplayName;
                if (!string.IsNullOrEmpty(user.Handle))
                    return user.Handle;
                if (!string.IsNullOrEmpty(user.Aliases))
                    return user.Aliases;
                return "unbekannt";
            }
    
    
            public static Sex GetUserInfoSexValue(this TUserSex sex)
            {
                return sex == TUserSex.usexMale ? Sex.Male : Sex.Female;
            }
    
            public static string ToLocalString(this Status status)
            {
                switch (status)
                {
                    case Status.Online:
                        return "online";
                    case Status.Away:
                        return "abwesend";
                    case Status.Offline:
                        return "offline";
                    case Status.Unknown:
                        return "unbekannt";
                    case Status.DoNotDisturb:
                        return "nicht stören";
                    case Status.NotAvailable:
                        return "nicht verfügbar";
                    case Status.SkypeMe:
                        return "Skype Me!";
                    case Status.SkypeOut:
                        return "Skype out";
                    default:
                        return String.Empty;
                }
            }
    
            public static Status GetStatusValue(this TOnlineStatus status)
            {
                switch (status)
                {
                    case TOnlineStatus.olsOnline:
                        return Status.Online;
                    case TOnlineStatus.olsAway:
                        return Status.Away;
                    case TOnlineStatus.olsOffline:
                        return Status.Offline;
                    case TOnlineStatus.olsDoNotDisturb:
                        return Status.DoNotDisturb;
                    case TOnlineStatus.olsNotAvailable:
                        return Status.NotAvailable;
                    case TOnlineStatus.olsSkypeMe:
                        return Status.SkypeMe;
                    case TOnlineStatus.olsSkypeOut:
                        return Status.SkypeOut;
                }
                return Status.Unknown;
            }
    
            public static TUserStatus GetTUserStatusValue(this Status status)
            {
                switch (status)
                {
                    case Status.Online:
                        return TUserStatus.cusOnline;
                    case Status.Away:
                        return TUserStatus.cusAway;
                    case Status.Offline:
                        return TUserStatus.cusOffline;
                    case Status.Unknown:
                        return TUserStatus.cusUnknown;
                    case Status.DoNotDisturb:
                        return TUserStatus.cusDoNotDisturb;
                    case Status.NotAvailable:
                        return TUserStatus.cusNotAvailable;
                    case Status.SkypeMe:
                        return TUserStatus.cusSkypeMe;
                }
                return TUserStatus.cusUnknown;
            }
    
            public static Status GetStatusValue(this TUserStatus status)
            {
                switch (status)
                {
                    case TUserStatus.cusOnline:
                        return Status.Online;
                    case TUserStatus.cusAway:
                        return Status.Away;
                    case TUserStatus.cusOffline:
                        return Status.Offline;
                    case TUserStatus.cusDoNotDisturb:
                        return Status.DoNotDisturb;
                    case TUserStatus.cusNotAvailable:
                        return Status.NotAvailable;
                    case TUserStatus.cusSkypeMe:
                        return Status.SkypeMe;
                }
                return Status.Unknown;
            }
    
            public static int GetImageIndex(this Status status)
            {
                switch (status)
                {
                    case Status.Online:
                        return 0;
                    case Status.Away:
                        return 1;
                    case Status.Offline:
                        return 4;
                    case Status.Unknown:
                        return 4;
                    case Status.DoNotDisturb:
                        return 2;
                    case Status.NotAvailable:
                        return 1;
                    case Status.SkypeMe:
                        return 0;
                    case Status.SkypeOut:
                        return 3;
                    default:
                        return 4;
                }
            }
    
            public static UserInfo GetUserInfo(this User user)
            {
                // TODO: Maybe take from some database!
                return new UserInfo {Name = user.GetSomeName(), Sex = user.Sex.GetUserInfoSexValue()};
            }
        }
    }
