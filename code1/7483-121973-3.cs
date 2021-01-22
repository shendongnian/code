        // <([be])pt[^>]+>.+?</\1pt>
    // 
    // Match the character "<" literally «<»
    // Match the regular expression below and capture its match into backreference number 1 «([be])»
    //    Match a single character present in the list "be" «[be]»
    // Match the characters "pt" literally «pt»
    // Match any character that is not a ">" «[^>]+»
    //    Between one and unlimited times, as many times as possible, giving back as needed (greedy) «+»
    // Match the character ">" literally «>»
    // Match any single character that is not a line break character «.+?»
    //    Between one and unlimited times, as few times as possible, expanding as needed (lazy) «+?»
    // Match the characters "</" literally «</»
    // Match the same text as most recently matched by backreference number 1 «\1»
    // Match the characters "pt>" literally «pt>»
