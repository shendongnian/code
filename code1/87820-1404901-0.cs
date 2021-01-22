    public class Car
    {
        public void Brake()
        {
              switch (this.BrakeType)
              {
                  case 1:  // antilock brakes
                    ....
                  case 2:  // 4-wheel disc brakes, no antilock
                    ....
                  case 3:  // rear-drum, front-disc brakes
                    ....
              }
         }
    }
