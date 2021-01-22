    <bri:ThumbViewr ImageUrl='<#Eval("ImagePath + Name") %>' ... />
    //And in your codebehid:
    public property ImagePath { get; set; }
    ...
    ImagePath = "...";
