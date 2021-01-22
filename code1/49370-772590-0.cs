    SystemTime.Now = () => new DateTime(2000,1,1);
    repository.ResetFailures(failedMsgs); 
    SystemTime.Now = () => new DateTime(2000,1,2);
    var msgs = repository.GetAllReadyMessages(); 
    Assert.AreEqual(2, msgs.Length);
