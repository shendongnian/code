    [AttributeUsage (AttributeTargets::Class)]
    public ref class ControlDescriptionAttribute : Attribute
    {
    public:
      ControlDescriptionAttribute (String ^name, String ^description) :
        _name (name),
        _description (description)
      {
      }
      property String ^Name
      {
        String ^get () { return _name; }
      }
      property String ^Description
      {
        String ^get () { return _description; }
      }
    private:
      String
        ^ _name,
        ^ _description;
    };
