    class Car {
       Bool CheckEngingLightIsOn = false;
       public void Ride( ... ){
        if( enginge.faultDetected == true ){
           TurnOnCheckEngineAlert( );
        }
       }
       public void TurnOnCheckEngineAlert( ){
          CheckEngingLightIsOn = true;
          if( CheckEngineLightSwitch != null ){
             CheckEngineLightSwitch.Invoke( ... )
          }
       }
    }
    
    class Driver {
       public Driver( Car car ){
          this.car = car;
          if( driverState != Drunk ){
           car.CheckEngineLightSwitch = TakeAction;
          }
       }
       public Drive( ){
          car.Ride( );
       }
       public void TakeAction( Car car, EventArgs e ){
          //get out, open the hood, check the engine...
          if( car.CheckEngingLightIsOn == true ){ "Light turned on
            //Check Engine
          }else{
            //continue driving
          }
       }
    }
