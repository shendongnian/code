    public class Person
    {
    	public virtual int Id { get; set; }
    	public virtual string Name { get; set; }
    
    	static Person()
    	{
    		Mapper.CreateMap<PersonDto, Person>();
    		Mapper.CreateMap<Person, PersonDto>();
    	}
    	
    	public Person(PersonDto dto)
    	{
    		Mapper.Map<PersonDto, Person>(dto, this);
    	}
    	
    	public PersonDto ToPersonDto()
    	{
    		var dto = new PersonDto();
    		Mapper.Map<Person, PersonDto>(this, dto);
    		return dto;
    	}
    }
