    // Inside Form1()
    private TestClass m_testClass;
    Form1()
    {
        m_testClass = new testClass(this);
        ....
    }
    // Inside testClass
    private Form1 m_testForm;
    testClass(Form1 formToTest)
    {
        m_testForm = formToTest;
    }
    void DoTest()
    {
        // use m_testForm here...
    }
