    class base
    {
    public:
        base()
        {
          // only initialize base's members
        }
 
        virtual ~base()
        {
          // only release base's members
        }
        virtual bool initialize(/* whatever goes here */) = 0;
    };
    class derived : public base
    {
    public:
        derived ()
        {
          // only initialize derived 's members
        }
 
        virtual ~derived ()
        {
          // only release derived 's members
        }
        virtual bool initialize(/* whatever goes here */)
        {
          // do your further initialization here
          // return success/failure
        }
    };
