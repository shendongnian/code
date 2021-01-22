    class Foo {
         class UserInfo { // move this outside if it makes sense to re-use it
              public int Name {get;set;}
              public int Id {get;set;}
         }
         UserInfo user;
         class OrderInfo { // move this outside if it makes sense to re-use it
             public string Reference {get;set;}
             public string Date {get;set;}
         }
         OrderInfo order;
    }
