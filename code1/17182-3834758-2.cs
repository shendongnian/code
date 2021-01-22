    "abc".IsLike("a*"); // true
    "Abc".IsLike("[A-Z][a-z][a-z]"); // true
    "abc123".IsLike("*###"); // true
    "hat".IsLike("?at"); // true
    "joe".IsLike("[!aeiou]*"); // true
    "joe".IsLike("?at"); // false
    "joe".IsLike("[A-Z][a-z][a-z]"); // false
