    private bool CheckAuthentication()
        {
            // WARNING : DO NOT simply return "true". By doing so, you are allowing
            // "anyone" to upload and list the files in your server. You must implement
            // some kind of session validation here. Even something very simple as...
            //
            //        return ( Session[ "IsAuthorized" ] != null && (bool)Session[ "IsAuthorized" ] == true );
            //
            // ... where Session[ "IsAuthorized" ] is set to "true" as soon as the
            // user logs in your system.
            MembershipUser m = Membership.GetUser();
            if (m != null)
            {
                return true;
            } else {
                return false;
            }
            //return false;
        }
