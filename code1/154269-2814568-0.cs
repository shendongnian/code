    public class MyCar
    {
       public bool GoVisitMyFriends(NotifyFriendsDelegate thingToDoWhenWeGetThere)
       {
             var doOurFriendsLikeUs = false;
             var driving = new DrivingClass();
             var didWeGetThere = driving.DoTheDrivingNowPlease();
             if(didWeGetThere)
             {
                  doOurFriendsLikeUs = thingToDoWhenWeGetThere(11);
             } 
             return doOurFriendsLikeUs;
       }
    }
