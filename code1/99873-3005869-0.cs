    struct ColData{
     int c1;
     string c2;
    };
    class Action {
     public abstract bool Undo(){}
     public abstract bool Redo(){}
    }
    class AddAction : Action{
     ColData data;
     public AddAction(ColData d){data = d;}
     public override bool Undo(){
         //remove the row
         //identify it with info from local field 'data'
     }
     public override bool Redo(){
         //add the row with info from local field 'data'
     }
     
    }
    //other actions like Delete, Update
