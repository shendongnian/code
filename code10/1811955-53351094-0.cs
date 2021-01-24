    public void ChangeStatus(int id){
        using(DBContext firstContext = new DBContext()){
            var firstCar = firstContext .Cars.FirstOrDefault(x=>x.id == id);
            firstCar .status = 1;
            context.SaveChanges();
            UpdateAnotherStatus(id);
            //at this point, the data set in the secondContext
            //did not update `firstCar` because they are completely seperate.
            //to overcome this eighter refetch (slow) or use the firstCar object or firstContext
            //to update status2
        }
    }
    
    public void UpdateAnotherStatus(int id){
        using(DBContext secondContext = new DBContext()){
            var secondCar = secondContext .Cars.FirstOrDefault(x=>x.id == id);
            secondCar .status2 = 2;
            secondContext .SaveChanges();
        }
    }
