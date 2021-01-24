     public FriendModel getEl(int i)
     {
         return lista.Where(f => f.id == i).FirstorDefault();
     }
   
