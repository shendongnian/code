    DateTime now = DateTime.Now;
    DateTime later = now + TimeSpan.FromHours(1.0);
    
    Assert.That( now, Is.EqualTo(now) );
    Assert.That( later. Is.EqualTo(now).Within(TimeSpan.FromHours(3.0));
    Assert.That( later, Is.EqualTo(now).Within(3).Hours;
