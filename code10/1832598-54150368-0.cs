C#
var result = from f in ADC.Friends select f;
List<Friend> SearchResult = new List<Friend>();
//ADC is the ApplicationDataContext
SearchResult = result.Where(x => x.UserFriend.Id.Equals(Id)).ToList();
var model = new FriendViewModel
        {
            FriendList = SearchResult
            //this is a List<Friend>
        };
        return PartialView(model);
to this
C#
var SearchResult = ADC.AspNetUsers.Select(x=>x.Friend).ToList(); //Maybe you will have FriendNavigation if you don't find Friend relationship.. use intellisense in that case
var model = new FriendViewModel
        {
            FriendList = SearchResult
            //this is a List<Friend>
        };
return PartialView(model);
