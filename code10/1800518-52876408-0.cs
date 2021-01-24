    public interface ITelemetryClientWrapper{
     void TrackEvent();
    }
    
    public class MyTelemetryClient : ITelemetryClientWrapper{
     public void TrackEvent(){
       // Use real TelemetryClient here, I guess it's not your class, right? If it's your class, just extract an interface from it
     }
    }
