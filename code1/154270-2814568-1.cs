    public class MyFunClass()
    {
        public bool NotifyFriendsByRammingTheirHouse(int howHard)
        {
             var rammingModule = new RammingModule();
             return rammingModule.RamFriendsHouse(howHard); 
        }
        public bool DoSomethingFun()
        {
             var car = new MyCar();
             var areWeCool = car.GoVisitMyFriends(NotifyFriendsByRammingTheirHouse);
             return areWeCool;
        }
    } 
  
