public class cAccountEmployee
{
    private cAccountEntity entity;
    public int id
    {
        get
        {
            return this.entity.id;
        }
        set
        {
            this.entity.id = value;
        }
    }
    public string name
    {
        get
        {
            return this.entity.name;
        }
        set
        {
            this.entity.name = value;
        }
    }
    public int accountholder_id
    {
        get
        {
            return this.entity.accountholder_id;
        }
        set
        {
            this.entity.accountholder_id = value;
        }
    }
    public System.Data.Linq.EntitySet&lt;cAccountEntityValue&gt; cAccountEntityValues
    {
        get
        {
            return this.entity.cAccountEntityValues;
        }
    }
    public cAccountHolder cAccountHolder
    {
        get
        {
            return this.entity.cAccountHolder;
        }
    }
    public cAccountEmployee()
    {
        this.entity = new cAccountEntity();
    }
    public cAccountEmployee(cAccountEntity entity)
    {
        this.entity = entity;
    }
    public string id_number
    {
        get
        {
            try
            {
                return this.entity.cAccountEntityValues.Single(e =&gt; e.type == 1).value;
            }
            catch (Exception)
            {
                return "";
            }
        }
        set
        {
            try
            {
                this.entity.cAccountEntityValues.Single(e =&gt; e.type == 1).value = value;
            }
            catch (Exception)
            {
                this.entity.cAccountEntityValues.Add(new cAccountEntityValue()
                                            {
                                                accountentity_id = this.id,
                                                cAccountEntity = this.entity,
                                                type = 1,
                                                value = value
                                            });
            }
        }
    }
}
//In the repository
public cAccountEmployee Single(int id)
    {
        return new cAccountEmployee(db.cAccountEntities.Single(a =&gt; a.id == id));
    }
