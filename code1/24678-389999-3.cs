    class Student : Person {
        String studentID;
        Student(String name, String studentID){
            // Now we need to initialize the Person part
            super(name);
            // and the special Student part
            this.studentID = studentID;
        }
    }
