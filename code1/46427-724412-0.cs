    partial class YourType { // only do this if direct enum mapping isn't an option
        public Status Status { // could also be string
             get {
                 switch(StatusCode) {
                      case 0: return Status.Open;
                      // etc
                 }
             }
        }
    }
