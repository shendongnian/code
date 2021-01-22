private string _email;
public string Email
{
    get
    {
        return this._email;
    }
    set
    {
        this._email = value;
        ReplaceList(); //**
    }
}
