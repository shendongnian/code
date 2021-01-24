    YourModel data=new YourModel();
    Person person=new Person();
    person.name="test name";
    .
    .
    data.Person=person;
    Policy policy1=new Policy();
    policy1.name="test name";
    .
    .
    Policy policy2=new Policy();
    policy2.name="test name 2";
    .
    .
    data.Policies.Add(policy1);
    data.Policies.Add(policy2);
    
    return Ok(data);
