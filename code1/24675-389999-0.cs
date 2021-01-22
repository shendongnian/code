    class Student {
        String name;
        String studentID;
        Course crsList = List<Course>; // "list of courses."
        Student(String name, String studentID ){
            // Make a new student, the "constructor"
            this.name = name;
            this.studentID = studentID;
        }
        addCourse(Course c){
            // Add a course to the student's list
            this.crsList.append(c); // Adds c to end of crsList
        }
    }
