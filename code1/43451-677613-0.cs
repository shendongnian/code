    <FlagsAttribute()> _
    Public Enum Skills As Byte
        None = 0
        Skill1 = 1
        Skill2 = 2
        Skill3 = 4
        Skill4 = 8
        Skill5 = 16
        Skill6 = 32
        Skill7 = 64
        Skill8 = 128
    End Enum
        Dim x As Byte = Skills.Skill4 Or Skills.Skill8 Or Skills.Skill6
        Dim count As Integer = CType(x, Skills).ToString().Split(","c).Count
