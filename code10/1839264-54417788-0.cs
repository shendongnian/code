    //     v----------------v--------------The type of properties_
    public BaseToolProperties Properties()
    {   //                              ^----------------the <T> was removed
        return properties_;
    }
    //     v--------------v----------------The type of propertiesNoValidate_
    public ScriptableObject PropertiesNoValidate()
    {   //                                      ^--------the <T> was removed
        return propertiesNoValidate_;
    }
