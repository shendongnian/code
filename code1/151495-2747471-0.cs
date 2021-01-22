    class Patient {
      int Id {get;set;}
      string PatientName {get;set;}
    }
    ...
    ActionResult SomeAction([MyCustomBinder("PatientName")] Patient patient) {...}
